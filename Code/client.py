# Save as client.py 
# Message Sender
import xbox
import os
import time
from marvelmind import MarvelmindHedge
from socket import *

#Function goes through possible Xbox controller inputs (not Dpad or start/back/Xbox button)
#Returns a list of if that button is pressed (1 if yes, 0 if no), as well as values corresponding
#to if the triggers/joysticks are being pressed, returns all 0 if nothing is pressed
def get_input(joy):
    msg = [0] * 12
    if(joy.A()):
        msg[0] = 1;
    if(joy.B()):
        msg[1] = 1;
    if(joy.X()):
        msg[2] = 1;
    if(joy.Y()):
        msg[3] = 1;
    if(joy.rightBumper()):
        msg[4] = 1;
    if(joy.leftBumper()):
        msg[5] = 1;
    msg[6] = joy.rightTrigger()
    msg[7] = joy.leftTrigger()
    msg[8] = joy.leftStick()[0]
    msg[9] = joy.leftStick()[1]
    msg[10] = joy.rightStick()[0]
    msg[11] = joy.rightStick()[1]
    return msg

host = "192.168.1.111" # set to IP address of target computer
port = 13001
buf = 1024
addr = (host, port)

#initialize Xbox controller
joy = xbox.Joystick()

#create socket
UDPSock = socket(AF_INET, SOCK_DGRAM)

#Marvelmind hedge setup
hedge = MarvelmindHedge(tty = "/dev/ttyAMC0", adr = 10, debug=False)
hedge.start()
hedge.print_position()

print("Press Back button to exit")

#Runs through everything and sends it to target computer
while not joy.Back():
    hedge_pos = hedge.position()
    controller = get_input(joy)
    print controller
    for i in hedge_pos:
        UDPSock.sendto(str(i), addr)
        (data, addr) = UDPSock.recvfrom(buf)
    for i in controller:
        UDPSock.sendto(str(i), addr)
        (data, addr) = UDPSock.recvfrom(buf)
    

UDPSock.sendto("exit", addr)
#clean up
UDPSock.close()
os._exit(0)
joy.close()