import customtkinter as ctk
import socket, pickle
from sklearn.tree import DecisionTreeClassifier
from CTkMessagebox import CTkMessagebox
from functools import partial


host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))


dtreemodel = pickle.load(open("dtreemodel.pkl",'rb'))
ctk.set_appearance_mode("dark")
ctk.set_default_color_theme("dark-blue")

window = ctk.CTk()
window.geometry("250x400")

alertVar = ctk.StringVar(value='Environment')
NotfiVar = ctk.StringVar(value='Scheduled')
ImmersivenessVar = ctk.StringVar(value='Browsing')

Alerts = ['Environment', 'Health', 'Maintenance', 'Security']
Notification = ['Scheduled','Status Update','Unscheduled']
Immersiveness = ['Browsing', 'DND', 'Highly', 'Moderate']

def showmsg(msg):
    CTkMessagebox(
        title="Alert Status",
        message=msg,
        icon="check", 
        option_1="Close"
    )
    
def ConnectFrameWork(Alert):
    sock.sendall(Alert.encode("UTF-8")) 
    if Alert == "-1":
        showmsg("Connection to Unity is terminated.")
        return
    genre = sock.recv(1024).decode("UTF-8")
    
    print(f"Recived genre {genre}")
    print([
        int(genre), Alerts.index(alertVar.get()),
        Notification.index(NotfiVar.get()),Immersiveness.index(ImmersivenessVar.get())])
    
    config = dtreemodel.predict([[
        int(genre), Alerts.index(alertVar.get()),
        Notification.index(NotfiVar.get()),Immersiveness.index(ImmersivenessVar.get())]])[0]
    print(f"{config}${alertVar.get()}${NotfiVar.get()}")
    
    sock.sendall(f"{config}${alertVar.get()}${NotfiVar.get()}".encode("UTF-8"))

def label(msg):
    ctk.CTkLabel(
        master=window,
        text=msg,
        font=("Times New Roman", 16),
    ).pack()
    
def UIpanel():
    label('To Simulate Events\nSelect from the given options\n')
    label("Set Alert Type")
    ctk.CTkOptionMenu(
        master=window,
        values=['Environment', 'Health', 'Maintenance', 'Security'],
        variable=alertVar).pack(pady=12, padx = 10)
    
    label("Set Notification Type")
    ctk.CTkOptionMenu(
        master=window,
        values=['Scheduled','Status Update','Unscheduled'],
        variable=NotfiVar).pack(pady=12, padx = 10)
    
    label("Set Immersiveness Type")
    ctk.CTkOptionMenu(
        master=window,
        values=['Browsing', 'DND', 'Highly', 'Moderate'],
        variable=ImmersivenessVar).pack(pady=12, padx = 10)
    
    
    ctk.CTkButton(
        master=window, 
        text= "Simulate",
        command=partial(ConnectFrameWork,'0')
        ).pack(pady=12, padx = 10)
    
    ctk.CTkButton(
        master=window, 
        text= "Close Connection",
        command=partial(ConnectFrameWork,'-1'),
        ).pack(pady=12, padx = 10)
    
    window.attributes('-topmost',True)
    window.mainloop()
    
UIpanel()