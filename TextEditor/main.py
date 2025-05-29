import sys
from PySide6.QtWidgets import (QApplication, QMainWindow, QTextEdit,
                               QToolBar, QFileDialog)
from PySide6.QtGui import QIcon, QKeySequence, QAction, QFont
from PySide6.QtCore import Qt


class TextEditor(QMainWindow):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Edytor tekstu")
        self.setGeometry(100, 100, 800, 600)

        self.text_edit = QTextEdit(self)
        self.setCentralWidget(self.text_edit)

        self.create_menu()
        self.create_toolbar()

    def create_menu(self):
        menu_bar = self.menuBar()

        file_menu = menu_bar.addMenu("Plik")

        new_action = QAction("Nowy", self)
        new_action.setShortcut(QKeySequence.New)
        new_action.triggered.connect(self.new_file)
        file_menu.addAction(new_action)

        open_action = QAction("Otwórz", self)
        open_action.setShortcut(QKeySequence.Open)
        open_action.triggered.connect(self.open_file)
        file_menu.addAction(open_action)

        save_action = QAction("Zapisz", self)
        save_action.setShortcut(QKeySequence.Save)
        save_action.triggered.connect(self.save_file)
        file_menu.addAction(save_action)

        close_action = QAction("Zamknij", self)
        close_action.setShortcut(QKeySequence.Close)
        close_action.triggered.connect(self.close)
        file_menu.addAction(close_action)

        edit_menu = menu_bar.addMenu("Edytuj")

        bold_action = QAction("Pogrubienie", self)
        bold_action.setShortcut(Qt.CTRL | Qt.Key_B)
        bold_action.triggered.connect(self.toggle_bold)
        edit_menu.addAction(bold_action)

        underline_action = QAction("Podkreślenie", self)
        underline_action.setShortcut(Qt.CTRL | Qt.Key_U)
        underline_action.triggered.connect(self.toggle_underline)
        edit_menu.addAction(underline_action)

        italic_action = QAction("Pochylenie", self)
        italic_action.setShortcut(Qt.CTRL | Qt.Key_I)
        italic_action.triggered.connect(self.toggle_italic)
        edit_menu.addAction(italic_action)

        align_left_action = QAction("Wyrównaj do lewej", self)
        align_left_action.triggered.connect(lambda: self.text_edit.setAlignment(Qt.AlignLeft))
        edit_menu.addAction(align_left_action)

        align_center_action = QAction("Wyrównaj do środka", self)
        align_center_action.triggered.connect(lambda: self.text_edit.setAlignment(Qt.AlignCenter))
        edit_menu.addAction(align_center_action)

        align_right_action = QAction("Wyrównaj do prawej", self)
        align_right_action.triggered.connect(lambda: self.text_edit.setAlignment(Qt.AlignRight))
        edit_menu.addAction(align_right_action)

    def create_toolbar(self):
        toolbar = QToolBar("Główny pasek narzędziowy", self)
        self.addToolBar(toolbar)

        new_icon = QIcon.fromTheme(QIcon.ThemeIcon.DocumentNew)
        open_icon = QIcon.fromTheme(QIcon.ThemeIcon.DocumentOpen)
        save_icon = QIcon.fromTheme(QIcon.ThemeIcon.DocumentSave)

        toolbar.addAction(new_icon, "Nowy", self.new_file)
        toolbar.addAction(open_icon, "Otwórz", self.open_file)
        toolbar.addAction(save_icon, "Zapisz", self.save_file)

        toolbar.addSeparator()

        bold_icon = QIcon.fromTheme(QIcon.ThemeIcon.FormatTextBold)
        underline_icon = QIcon.fromTheme(QIcon.ThemeIcon.FormatTextUnderline)
        italic_icon = QIcon.fromTheme(QIcon.ThemeIcon.FormatTextItalic)

        toolbar.addAction(bold_icon, "Pogrubienie", self.toggle_bold)
        toolbar.addAction(underline_icon, "Podkreślenie", self.toggle_underline)
        toolbar.addAction(italic_icon, "Pochylenie", self.toggle_italic)

        toolbar.addSeparator()

        justify_left_icon = QIcon.fromTheme(QIcon.ThemeIcon.FormatJustifyLeft)
        justify_center_icon = QIcon.fromTheme(QIcon.ThemeIcon.FormatJustifyCenter)
        justify_right_icon = QIcon.fromTheme(QIcon.ThemeIcon.FormatJustifyRight)

        toolbar.addAction(justify_left_icon, "Wyrównaj do lewej", lambda: self.text_edit.setAlignment(Qt.AlignLeft))
        toolbar.addAction(justify_center_icon, "Wyrównaj do środka", lambda: self.text_edit.setAlignment(Qt.AlignCenter))
        toolbar.addAction(justify_right_icon, "Wyrównaj do prawej", lambda: self.text_edit.setAlignment(Qt.AlignRight))

    def new_file(self):
        self.text_edit.clear()

    def open_file(self):
        options = QFileDialog.Options()
        file_name, _ = QFileDialog.getOpenFileName(self, "Otwórz plik", "",
                                                   "", options=options)
        if file_name:
            with open(file_name, 'r') as file:
                self.text_edit.setText(file.read())

    def save_file(self):
        options = QFileDialog.Options()
        file_name, _ = QFileDialog.getSaveFileName(self, "Zapisz plik", "",
                                                   "", options=options)
        if file_name:
            with open(file_name, 'w') as file:
                file.write(self.text_edit.toPlainText())

    def toggle_bold(self):
        fmt = self.text_edit.currentCharFormat()
        fmt.setFontWeight(QFont.Bold if fmt.fontWeight() != QFont.Bold else QFont.Normal)
        self.text_edit.setCurrentCharFormat(fmt)

    def toggle_underline(self):
        fmt = self.text_edit.currentCharFormat()
        fmt.setFontUnderline(not fmt.fontUnderline())
        self.text_edit.setCurrentCharFormat(fmt)

    def toggle_italic(self):
        fmt = self.text_edit.currentCharFormat()
        fmt.setFontItalic(not fmt.fontItalic())
        self.text_edit.setCurrentCharFormat(fmt)


if __name__ == "__main__":
    app = QApplication(sys.argv)
    editor = TextEditor()
    editor.show()
    sys.exit(app.exec())
