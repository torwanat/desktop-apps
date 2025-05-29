from tkinter import *


def loginLayout(window, loginHandler):
    etLogin = Entry(window)
    etPassword = Entry(window)
    btLogin = Button(window, text='Login', command=lambda: loginHandler(etLogin.get(), etPassword.get()))
    etLogin.grid(column=1, row=0)
    etPassword.grid(column=1, row=1)
    btLogin.grid(column=0, columnspan=3, row=2)


def mainLayout(window, add, remove, select, databases, connection):
    for widget in window.winfo_children():
        widget.destroy()

    btAdd = Button(window, text='Add', command=lambda: add(window, connection))
    btAdd.grid(row=0, column=0, columnspan=3)

    for index, database in enumerate(databases):
        lbDatabase = Label(window, text=database)
        btEdit = Button(window, text='Edit', command=lambda thisDatabase=database: select(thisDatabase, connection))
        btRemove = Button(window, text='Remove', command=lambda thisDatabase=database: remove(thisDatabase, connection))
        lbDatabase.grid(column=0, row=index + 1)
        btEdit.grid(column=1, row=index + 1)
        btRemove.grid(column=2, row=index + 1)
