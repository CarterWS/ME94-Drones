# Save as server.py 
# Message Receiver
import os
import csv
import array as arr
import time
import zmq
from socket import *

host = gethostbyname('0.0.0.0'); #change this to the IP of the target computer
port = 13001
buf = 1024

i = 0
length = 17
int_data = 0
#a = [0] * length

#Linux socket
addr = (host, port)
UDPSock = socket(AF_INET, SOCK_DGRAM)
UDPSock.bind(addr)	

#Unity socket
context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

print "Waiting to receive messages..."
while True:
    #Recieves the data from other computer
    (data, addr) = UDPSock.recvfrom(buf)
    print "Received message: " + data
    if data == "exit":
        break
    #print i #This is an easy debug tool to see if messages are actually being transmitted
    
    #Sends the data to the unity simulation
    if((i%length) < 11):
        int_data = int(data)
        int_data = int_data + ((i%17) * 10)
        data = str(int_data)

    elif((i%length) >= 11):
        float_data = float(data)
        float_data = float_data + ((i%17) * 10)
        data = str(float_data)

    msg = socket.recv()
    socket.send(data)
    i = i + 1
    UDPSock.sendto("", addr)

#Closes the sockets
UDPSock.close()
os._exit(0)
