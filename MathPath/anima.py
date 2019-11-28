import sys
import sqlite3
import os
con = sqlite3.connect('Assets\Plugins\juego.db')
import random
import matplotlib
# Make sure that we are using QT5
matplotlib.use('Qt5Agg')
from PyQt5 import QtCore, QtWidgets
from PyQt5.QtWidgets import QApplication, QMainWindow, QMenu, QVBoxLayout,QHBoxLayout, QSizePolicy, QMessageBox, QWidget
import numpy as np
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.figure import Figure
from matplotlib.animation import FuncAnimation

from random import choice
from PyQt5.QtWidgets import *
from PyQt5 import QtCore
from PyQt5.QtWidgets import QApplication, QMainWindow, QMenu, QVBoxLayout, QSizePolicy, QMessageBox, QWidget



class MyMplCanvas(FigureCanvas):
    def __init__(self, parent=None, width=5, height=4, dpi=100):
        fig = Figure(figsize=(width, height), dpi=dpi)
        self.ax = fig.add_subplot(111)
        self.compute_initial_figure()
        FigureCanvas.__init__(self, fig)
        self.setParent(parent)
        FigureCanvas.setSizePolicy(self,
                                   QtWidgets.QSizePolicy.Expanding,
                                   QtWidgets.QSizePolicy.Expanding)
        FigureCanvas.updateGeometry(self)

    def compute_initial_figure(self):
        pass

class ApplicationWindow(QtWidgets.QMainWindow):
    def __init__(self):
        QtWidgets.QMainWindow.__init__(self)
        self.resize(940,650)
        self.setWindowTitle("Procesos")
        self.main_widget = QtWidgets.QWidget(self)

        self.canvas =  MyMplCanvas( self.main_widget,width=5, height=4, dpi=100) ###attention###
        vertical_layout = QVBoxLayout(self.main_widget)
        vertical_layout.addWidget(self.canvas)
        self.Mpl= QtWidgets.QWidget(self.main_widget)
        self.Mpl.setLayout(vertical_layout)
        self.Mpl.setGeometry(QtCore.QRect(20, 130, 850, 500))
#Creacion de Botones
        #Botones de Control
        self.FCFS = QtWidgets.QPushButton("Usuarios-Puntaje",self.main_widget)
        self.FCFS.setGeometry(QtCore.QRect(20, 30, 250, 80))
        self.FCFS.setStyleSheet("font: 16pt \"MS Shell Dlg 2\";")
        self.FCFS.setObjectName("Usuarios-Puntaje")
        #Boton de paro y salida
        self.stop_button = QtWidgets.QPushButton("stop",self.main_widget)
        self.stop_button.setGeometry(QtCore.QRect(870, 250, 50, 23))
        self.stop_button.setObjectName("stop_button")
        self.exit_button = QtWidgets.QPushButton("exit",self.main_widget)
        self.exit_button.setGeometry(QtCore.QRect(870, 290, 50, 23))
        self.exit_button.setObjectName("exit_button")
#Inicializar Botones
        self.FCFS.clicked.connect(self.pro1)
        self.stop_button.clicked.connect(self.on_stop)
        self.exit_button.clicked.connect(self.on_exit)
        self.setCentralWidget(self.main_widget)



    def update_line(self, i):
        return self.canvas.ax.plot([i,i*2],[i*2,i/2])


    def pro1(self):
    #Array a ejecutar
        cursorObj = con.cursor()
        cursorObj.execute('SELECT * FROM usuario')
        rows = cursorObj.fetchall()
        print(rows)
        self.canvas.ax.plot([i[0] for i in rows],[i[2] for i in rows])
        self.canvas.draw()
        print(12)
        
    def on_start(self):
        self.ani = FuncAnimation(self.canvas.figure, self.update_line,\
                                 frames=[i for i in 100],
                                 blit=True, interval=100, repeat=False)
    def on_stop(self):
        self.ani._stop()

    def on_exit(self):
        self.close()

if __name__ == "__main__":
    App = QApplication(sys.argv)
    aw = ApplicationWindow()
    aw.show()
    App.exit()
    sys.exit(App.exec_())


