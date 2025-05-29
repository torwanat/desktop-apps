import sys

from PySide6.QtCore import Qt, QSize
from PySide6.QtGui import QAction
from PySide6.QtWidgets import QApplication, QLabel, QMainWindow, QMenu, QPushButton, QLineEdit, QWidget, QVBoxLayout


class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Menu kontekstowe na sygnałach")
        self.setMinimumSize(QSize(400, 300))

        self.central_widget = QWidget()
        self.setCentralWidget(self.central_widget)

        self.layout = QVBoxLayout()
        self.central_widget.setLayout(self.layout)

        self.input = QLineEdit(self)
        self.input.setFixedWidth(200)
        self.layout.addWidget(self.input)

        self.output = QLabel(self)
        self.output.setFixedWidth(200)
        self.layout.addWidget(self.output)

        self.setContextMenuPolicy(Qt.CustomContextMenu)
        self.customContextMenuRequested.connect(self.on_context_menu)

    def on_context_menu(self, pos):
        context = QMenu(self)
        max_action = QAction("Max", self)
        min_action = QAction("Min", self)
        avg_action = QAction("Average", self)
        asc_action = QAction("Ascending", self)
        desc_action = QAction("Descending", self)

        max_action.triggered.connect(lambda: self.context_menu_action("max"))
        min_action.triggered.connect(lambda: self.context_menu_action("min"))
        avg_action.triggered.connect(lambda: self.context_menu_action("average"))
        asc_action.triggered.connect(lambda: self.context_menu_action("ascending"))
        desc_action.triggered.connect(lambda: self.context_menu_action("descending"))

        context.addAction(max_action)
        context.addAction(min_action)
        context.addAction(avg_action)
        context.addAction(asc_action)
        context.addAction(desc_action)
        context.exec(self.mapToGlobal(pos))

    def context_menu_action(self, action):
        numbers = self.input.text().split(";")
        result = ""

        if action == "max":
            result = max(int(n) for n in numbers)
        elif action == "min":
            result = min(int(n) for n in numbers)
        elif action == "average":
            result = sum(int(n) for n in numbers)/len(numbers)
        elif action == "ascending":
            n = len(numbers)

            for i in range(n):
                for j in range(n-i-1):
                    if int(numbers[j]) > int(numbers[j + 1]):
                        numbers[j], numbers[j+1] = numbers[j+1], numbers[j]

            result = ' '.join(numbers)
        else:
            n = len(numbers)

            for i in range(n):
                for j in range(n-i-1):
                    if int(numbers[j]) < int(numbers[j + 1]):
                        numbers[j], numbers[j + 1] = numbers[j + 1], numbers[j]

            result = ' '.join(numbers)

        self.output.setText(str(result))


app = QApplication(sys.argv)

window = MainWindow()
window.show()

app.exec()