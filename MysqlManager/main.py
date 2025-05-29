from tkinter import *

import database
import layout

window = Tk()
window.title("MySqlManager")
window.geometry("300x400")


def addDatabase(window, connection):
    tlAdd = Toplevel(window)
    etName = Entry(tlAdd)
    btAdd = Button(tlAdd, text='Add', command=lambda: [database.addDatabase(etName.get(), connection), refresh(window, connection)])
    etName.pack()
    btAdd.pack()


def refresh(window, connection):
    layout.mainLayout(window, addDatabase, removeDatabase, selectDatabase, database.showDatabases(connection),
                      connection)


def removeDatabase(name, connection):
    database.removeDatabase(name, connection)
    layout.mainLayout(window, addDatabase, removeDatabase, selectDatabase, database.showDatabases(connection),
                      connection)


def selectDatabase():
    pass


def loginHandler(name, password):
    connection = database.connect(name, password)
    layout.mainLayout(window, addDatabase, removeDatabase, selectDatabase, database.showDatabases(connection), connection)


layout.loginLayout(window, loginHandler)

window.mainloop()
