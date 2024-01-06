import socket
import time

host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))
k = 0
print("To simulate an Event\nPress 0 to give door bell alert.\npress 1 to give cab alert")
try:
    while True:
        res = input("Enter the Input: ")
        
        sock.sendall(res.encode("UTF-8"))
        if res == "-1":
             break
        
        location = sock.recv(1024).decode("UTF-8")
        
        print(f"Recied location {location}")

        sock.sendall(location.encode("UTF-8"))

        print(sock.recv(1024).decode())

except KeyboardInterrupt:
        print("Exited.............")


