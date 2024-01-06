import customtkinter as ctk
from CTkMessagebox import CTkMessagebox
from functools import partial
import socket, pickle
# from sklearn.tree import DecisionTreeClassifier

# host, port = "127.0.0.1", 25001
# sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
# sock.connect((host, port))


# dtreemodel = pickle.load(open("dtreemodel.pkl",'rb'))


ctk.set_appearance_mode("dark")
ctk.set_default_color_theme("dark-blue")


window = ctk.CTk()
val = ctk.IntVar()
window.geometry("250x410")

Alerts = {
    "1":["Door Bell", "Someone waiting for you at your door step.\nLooks like it's time to take a break"],
    "0":["Cab Alert","Your Cab is 1 Km away from you.\nIt'll reach in 5-10 minutes."],
    "3":["Smart Appliance Alert", "Alert from your smart home appliances.\nLooks like it's time to take a break."],
    "-1":["Close Connection"]
    }
def showmsg(msg):
    CTkMessagebox(
        title="Alert Status",
        message=msg,
        icon="check", 
        option_1="Close"
    )

def radiobutton(name, value):
    ctk.CTkRadioButton(
        master=window,
        text=name,
        value=value,
        variable=val,
        radiobutton_height=15,
        radiobutton_width=15
    ).pack(pady=12, padx = 10)

def AlertOptions():
    ctk.CTkLabel(
        master=window,
        text="To Simulate Events\nPress the buttons",
        font=("Times New Roman", 16),
    ).pack(pady=12, padx = 10)


    for i in Alerts.keys():
        ctk.CTkButton(
            master=window, 
            text= Alerts[i][0],
            command=partial(ConnectFrameWork,i),
        ).pack(pady=12, padx = 10)
    
    radiobutton("Browsing",0)
    radiobutton("Highly",2)
    radiobutton("Moderate",3)

    window.attributes('-topmost',True)
    window.mainloop()

def ConnectFrameWork(Alert):
    # sock.sendall(Alert.encode("UTF-8")) 
    # if Alert == "-1":
    #     showmsg("Connection to Unity is terminated.")
    #     return
    
    # location = sock.recv(1024).decode("UTF-8")
    
    # print(f"Recived location {location}")
    
    # config = dtreemodel.predict([[int(location),Alert,val.get()]])[0]
    # sock.sendall(f"{config}${Alerts[Alert][0]}${Alerts[Alert][1]}".encode("UTF-8"))
    print("tada")

AlertOptions()