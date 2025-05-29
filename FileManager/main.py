import shutil
import sys
import os
from PySide6.QtWidgets import QApplication, QMainWindow, QTreeView, QVBoxLayout, QWidget, QFileSystemModel, QFileDialog, \
    QPushButton, QLineEdit, QMessageBox, QTextEdit, QInputDialog


class FileManager(QMainWindow):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("File Manager")
        self.setGeometry(100, 100, 800, 600)

        self.model = QFileSystemModel()
        self.model.setRootPath("")

        self.tree = QTreeView()
        self.tree.setModel(self.model)
        self.tree.setRootIndex(self.model.index(os.path.expanduser('~')))
        self.tree.setColumnWidth(0, 250)

        self.create_button = QPushButton("Create Folder")
        self.create_button.clicked.connect(self.create_folder)

        self.create_file_button = QPushButton("Create Text File")
        self.create_file_button.clicked.connect(self.create_text_file)

        self.rename_button = QPushButton("Rename")
        self.rename_button.clicked.connect(self.rename_item)

        self.delete_button = QPushButton("Delete")
        self.delete_button.clicked.connect(self.delete_item)

        self.copy_button = QPushButton("Copy")
        self.copy_button.clicked.connect(self.copy_item)

        self.move_button = QPushButton("Move")
        self.move_button.clicked.connect(self.move_item)

        self.file_edit = QTextEdit()
        self.file_edit.setPlaceholderText("Edit text file contents")

        self.save_button = QPushButton("Save")
        self.save_button.clicked.connect(self.save_file)

        self.view_button = QPushButton("View Text File")
        self.view_button.clicked.connect(self.view_text_file)

        layout = QVBoxLayout()
        layout.addWidget(self.tree)
        layout.addWidget(self.create_button)
        layout.addWidget(self.create_file_button)
        layout.addWidget(self.rename_button)
        layout.addWidget(self.delete_button)
        layout.addWidget(self.copy_button)
        layout.addWidget(self.move_button)
        layout.addWidget(self.file_edit)
        layout.addWidget(self.save_button)
        layout.addWidget(self.view_button)

        central_widget = QWidget()
        central_widget.setLayout(layout)
        self.setCentralWidget(central_widget)

    def create_folder(self):
        index = self.tree.currentIndex()
        path = self.model.filePath(index)
        new_folder_name, ok = QInputDialog.getText(self, "Create Folder", "Enter folder name:")
        if ok and new_folder_name:
            os.makedirs(os.path.join(path, new_folder_name))
            self.model.setRootPath("")
            self.tree.setRootIndex(self.model.index(os.path.expanduser('~')))

    def create_text_file(self):
        index = self.tree.currentIndex()
        path = self.model.filePath(index)
        new_file_name, ok = QFileDialog.getSaveFileName(self, "Create Text File", os.path.join(path, "New File.txt"),
                                                        "Text Files (*.txt)")
        if ok and new_file_name:
            with open(new_file_name, 'w') as file:
                file.write("")  # Write an empty string to create an empty text file
            self.model.setRootPath("")
            self.tree.setRootIndex(self.model.index(os.path.expanduser('~')))

    def rename_item(self):
        index = self.tree.currentIndex()
        path = self.model.filePath(index)
        new_name, ok = QInputDialog.getText(self, "Rename", "Enter new name:")
        if ok and new_name:
            os.rename(path, os.path.join(os.path.dirname(path), new_name))
            self.model.setRootPath("")
            self.tree.setRootIndex(self.model.index(os.path.expanduser('~')))

    def delete_item(self):
        index = self.tree.currentIndex()
        path = self.model.filePath(index)
        if os.path.isdir(path):
            os.rmdir(path)
        else:
            os.remove(path)
        self.model.setRootPath("")
        self.tree.setRootIndex(self.model.index(os.path.expanduser('~')))

    def copy_item(self):
        index = self.tree.currentIndex()
        path = self.model.filePath(index)
        destination_folder = QFileDialog.getExistingDirectory(self, "Select destination folder")
        if destination_folder:
            destination_path = os.path.join(destination_folder, os.path.basename(path))
            if os.path.isdir(path):
                shutil.copytree(path, destination_path)
            else:
                shutil.copy2(path, destination_path)

    def move_item(self):
        index = self.tree.currentIndex()
        path = self.model.filePath(index)
        destination_folder = QFileDialog.getExistingDirectory(self, "Select destination folder")
        if destination_folder:
            destination_path = os.path.join(destination_folder, os.path.basename(path))
            if os.path.isdir(path):
                shutil.move(path, destination_path)
            else:
                shutil.move(path, destination_path)

    def check_if_file_exists(self):
        index = self.tree.currentIndex()
        path = self.model.filePath(index)
        if not os.path.exists(path):
            QMessageBox.warning(self, "Error", "No file selected or file does not exist.")
            self.file_edit.setPlainText("")
            return False
        if not os.path.isfile(path):
            QMessageBox.warning(self, "Error", "Selected item is not a file.")
            self.file_edit.setPlainText("")
            return False
        return path

    def save_file(self):
        path = self.check_if_file_exists()
        if path:
            text = self.file_edit.toPlainText()
            with open(path, 'w') as file:
                file.write(text)
            self.file_edit.setPlainText("")
            QMessageBox.information(self, "Success", "File saved successfully.")

    def view_text_file(self):
        path = self.check_if_file_exists()
        if path:
            with open(path, 'r') as file:
                text = file.read()
                self.file_edit.setPlainText(text)


if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = FileManager()
    window.show()
    sys.exit(app.exec())
