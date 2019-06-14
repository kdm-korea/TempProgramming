import sys
from enum import Enum
from PyQt5 import QtWidgets
from PyQt5 import uic

class Form(QtWidgets.QDialog):
    def __init__(self, parent=None):
        QtWidgets.QDialog.__init__(self, parent)
        self.ui = uic.loadUi("Main.ui")
        self.ui.show()

class Draw(Enum):
    Line = 0
    Triangle = 1
    Square = 2
    Circle = 3
    Eraser = 4


if __name__ == '__main__':
    app = QtWidgets.QApplication(sys.argv)
    w = Form()
    sys.exit(app.exec())


def square(self):
    print()

def circle(self):
    print()

def line(self):
    print()

def triangle(self):
    print()

def eraser(self):
    print()

def size(self):
    print()