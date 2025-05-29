import sys

from PySide6.QtCore import Qt
from PySide6.QtGui import QAction
from PySide6.QtWidgets import QMainWindow, QApplication, QWidget, QLineEdit, QMenu, QToolBar, QLabel


class SortingApp(QMainWindow):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("MenuBarSort")
        self.setGeometry(100, 100, 300, 300)

        self.init_UI()
        self.init_toolbar()

    def init_UI(self):
        main_widget = QWidget(self)
        self.tb = QLineEdit(self)
        self.tb.move(50, 50)
        self.tb.resize(200, 25)

        self.lb = QLabel(self)
        self.lb.move(50, 100)
        self.lb.resize(200, 25)

    def init_toolbar(self):
        toolbar = QToolBar("Toolbar")
        self.addToolBar(toolbar)

        bubble_sort_action = QAction("Bubble", self)
        bubble_sort_action.triggered.connect(self.bubble_sort)
        toolbar.addAction(bubble_sort_action)
        bubble_sort_action.setShortcut("Ctrl+B")

        insertion_sort_action = QAction("Insertion", self)
        insertion_sort_action.triggered.connect(self.insertion_sort)
        toolbar.addAction(insertion_sort_action)
        insertion_sort_action.setShortcut("Ctrl+I")

        quick_sort_action = QAction("Quick", self)
        quick_sort_action.triggered.connect(self.quick_sort)
        toolbar.addAction(quick_sort_action)
        quick_sort_action.setShortcut("Ctrl+Q")

    def get_data(self):
        return [int(el) for el in (self.tb.text().split(",")) if el != ""]

    def bubble_sort(self):
        data = self.get_data()

        changed = True
        while changed:
            changed = False
            for i in range(len(data) - 1):
                if data[i] > data[i + 1]:
                    data[i], data[i + 1] = data[i + 1], data[i]
                    changed = True

        print(data)
        self.lb.setText(",".join([str(el) for el in data]))

    def insertion_sort(self):
        data = self.get_data()

        for i in range(1, len(data)):
            key = data[i]
            j = i - 1
            while j >= 0 and key < data[j]:
                data[j + 1] = data[j]
                j -= 1
            data[j + 1] = key

        print(data)
        self.lb.setText(",".join([str(el) for el in data]))

    def quick_sort(self):
        def quick_sort_func(data, low, high):
            def partition(data, start, end):
                pivot = data[end]
                i = start - 1
                for j in range(start, end):
                    if data[j] <= pivot:
                        i = i + 1
                        data[i], data[j] = data[j], data[i]
                data[i + 1], data[end] = data[end], data[i + 1]

                return i + 1
            if low < high:
                piv = partition(data, low, high)
                quick_sort_func(data, low, piv - 1)
                quick_sort_func(data, piv + 1, high)

        data = self.get_data()
        quick_sort_func(data, 0, len(data) - 1)
        print(data)
        self.lb.setText(",".join([str(el) for el in data]))


if __name__ == "__main__":
    app = QApplication([])
    window = SortingApp()
    window.show()
    app.exec()