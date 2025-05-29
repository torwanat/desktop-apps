import mysql.connector
import sqlite3


def connect(user, password):
    mysqlDB = mysql.connector.connect(
        host='localhost',
        user=user,
        passwd=password
    )
    return mysqlDB


def showDatabases(connection):
    cursor = connection.cursor()
    cursor.execute('SHOW DATABASES')
    return cursor


def removeDatabase(name, connection):
    cursor = connection.cursor()
    tupla = (name[0])
    print(tupla)
    cursor.execute('DROP DATABASE %s', tupla)


def addDatabase(name, connection):
    cursor = connection.cursor()
    cursor.execute('CREATE DATABASE ' + name)
