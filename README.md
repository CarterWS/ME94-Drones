# ME94-Drones

# Please read before attempting to use.

This github is design for two computers, one running the marvelmind system and taking controller inputs, and the other runnning the unity simulation. The marvelmind computer should have the client.py file running. The unity computer should have the unity simulation as well as the server.py file running. 

The code for all of this is in the code folder, and the unity project is the folder titled "Drones"

The IPs of each computer can be found by System Preferences/Network on Mac and by ifconfig on Linux

The way this works is the computer running the marvelmind system sends both the location data and the controller inputs over to the computer running the unity system via the socket between the client.py file and the server.py. The socket between the server.py file and the unity HelloClient.cs file then sends this data over to the unity system. Currently the locations are not used for anything because I could not test it, but the CheckLocation.cs script should be able to process the locations if attached to the drone objects.
