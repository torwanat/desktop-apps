import sqlite3
import sys

from PySide6.QtCore import Qt, QDateTime, QTimer
from PySide6.QtWidgets import QApplication, QWidget, QVBoxLayout, QHBoxLayout, QPushButton, QLineEdit, \
    QListWidget, QDateTimeEdit, QListWidgetItem


class TaskManagerApp(QWidget):
    def __init__(self):
        super(TaskManagerApp, self).__init__()

        self.init_ui()

        self.init_db()

        self.load_tasks()

        self.timer = QTimer(self)
        self.timer.timeout.connect(self.load_tasks)
        self.timer.start(30000)

    def init_ui(self):
        self.setWindowTitle('Task Manager')
        self.setGeometry(100, 100, 500, 400)

        self.task_list = QListWidget(self)
        self.task_list.setSelectionMode(QListWidget.SingleSelection)

        self.task_name_input = QLineEdit(self)
        self.task_name_input.setPlaceholderText('Nazwa zadania')

        self.deadline_input = QDateTimeEdit(self)
        self.deadline_input.setCalendarPopup(True)
        self.deadline_input.setDateTime(QDateTime.currentDateTime())

        self.add_button = QPushButton('Dodaj', self)
        self.edit_button = QPushButton('Edytuj', self)
        self.mark_done_button = QPushButton('Oznacz jako wykonane', self)
        self.delete_button = QPushButton('Usuń', self)

        layout = QVBoxLayout(self)
        layout.addWidget(self.task_list)

        form_layout = QHBoxLayout()
        form_layout.addWidget(self.task_name_input)
        form_layout.addWidget(self.deadline_input)

        button_layout = QHBoxLayout()
        button_layout.addWidget(self.add_button)
        button_layout.addWidget(self.edit_button)
        button_layout.addWidget(self.mark_done_button)
        button_layout.addWidget(self.delete_button)

        layout.addLayout(form_layout)
        layout.addLayout(button_layout)

        self.add_button.clicked.connect(self.add_task)
        self.edit_button.clicked.connect(self.edit_task)
        self.mark_done_button.clicked.connect(self.mark_done)
        self.delete_button.clicked.connect(self.delete_task)

    def init_db(self):
        self.conn = sqlite3.connect('tasks.db')
        self.cursor = self.conn.cursor()

        self.cursor.execute('''
            CREATE TABLE IF NOT EXISTS tasks (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT,
                deadline DATETIME,
                done INTEGER
            )
        ''')
        self.conn.commit()

    def load_tasks(self):
        self.task_list.clear()
        self.cursor.execute('SELECT * FROM tasks')
        tasks = self.cursor.fetchall()

        for task in tasks:
            task_name = task[1]
            deadline = QDateTime.fromString(task[2], Qt.ISODate)
            done = task[3]

            item = QListWidgetItem(f'{task_name} - {deadline.toString(Qt.TextDate)}')
            item.setData(Qt.UserRole, task[0])
            if not done and deadline < QDateTime.currentDateTime():
                item.setBackground(Qt.red)
            elif done:
                item.setBackground(Qt.green)
            self.task_list.addItem(item)

    def add_task(self):
        task_name = self.task_name_input.text()
        deadline = self.deadline_input.dateTime().toString(Qt.ISODate)

        if task_name:
            self.cursor.execute('INSERT INTO tasks (name, deadline, done) VALUES (?, ?, ?)', (task_name, deadline, 0))
            self.conn.commit()
            self.load_tasks()
            self.clear_inputs()

    def edit_task(self):
        selected_item = self.task_list.currentItem()
        new_name = self.task_name_input.text()

        if selected_item and new_name:
            task_id = selected_item.data(Qt.UserRole)
            new_deadline = self.deadline_input.dateTime().toString(Qt.ISODate)

            self.cursor.execute('UPDATE tasks SET name=?, deadline=? WHERE id=?', (new_name, new_deadline, task_id))
            self.conn.commit()
            self.load_tasks()
            self.clear_inputs()

    def mark_done(self):
        selected_item = self.task_list.currentItem()

        if selected_item:
            task_id = selected_item.data(Qt.UserRole)
            self.cursor.execute('UPDATE tasks SET done=1 WHERE id=?', (task_id,))
            self.conn.commit()
            self.load_tasks()

    def delete_task(self):
        selected_item = self.task_list.currentItem()

        if selected_item:
            task_id = selected_item.data(Qt.UserRole)
            self.cursor.execute('DELETE FROM tasks WHERE id=?', (task_id,))
            self.conn.commit()
            self.load_tasks()
            self.clear_inputs()

    def clear_inputs(self):
        self.task_name_input.clear()
        self.deadline_input.setDateTime(QDateTime.currentDateTime())


if __name__ == '__main__':
    app = QApplication(sys.argv)
    window = TaskManagerApp()
    window.show()
    sys.exit(app.exec())

