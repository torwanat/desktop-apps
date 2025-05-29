import tkinter as tk
from tkinter.filedialog import askopenfilename, asksaveasfilename

from _tkinter import TclError


def open_file():
    """Open a file for editing."""
    filepath = askopenfilename(
        filetypes=[("Text Files", "*.txt"), ("All Files", "*.*")]
    )
    if not filepath:
        return
    txt_edit.delete(1.0, tk.END)
    with open(filepath, "r") as input_file:
        text = input_file.read()
        txt_edit.insert(tk.END, text)
    window.title(f"Text Editor Application - {filepath}")


def save_file():
    """Save the current file as a new file."""
    filepath = asksaveasfilename(
        defaultextension="txt",
        filetypes=[("Text Files", "*.txt"), ("All Files", "*.*")],
    )
    if not filepath:
        return
    with open(filepath, "w") as output_file:
        text = txt_edit.get(1.0, tk.END)
        output_file.write(text)
    window.title(f"Text Editor Application - {filepath}")


def underline():
    try:
        if txt_edit.tag_nextrange('underline_selection', 'sel.first', 'sel.last') != ():
            txt_edit.tag_remove('underline_selection', 'sel.first', 'sel.last')
        else:
            txt_edit.tag_add('underline_selection', 'sel.first', 'sel.last')
            txt_edit.tag_configure('underline_selection', underline=True)
    except TclError:
        pass


def change_bold():
    try:
        if "boldtext" in txt_edit.tag_names("sel.first"):
            txt_edit.tag_remove("boldtext", "sel.first", "sel.last")
        else:
            txt_edit.tag_add("boldtext", "sel.first", "sel.last")
    except TclError:
        pass


window = tk.Tk()
window.title("Text Editor Application")
window.rowconfigure(0, minsize=800, weight=1)
window.columnconfigure(1, minsize=800, weight=1)

txt_edit = tk.Text(window)
fr_buttons = tk.Frame(window, relief=tk.RAISED, bd=2)
btn_open = tk.Button(fr_buttons, text="Open", command=open_file)
btn_save = tk.Button(fr_buttons, text="Save As...", command=save_file)
btn_underline = tk.Button(fr_buttons, text="underline", command=underline)

btn_open.grid(row=0, column=0, sticky="ew", padx=5, pady=5)
btn_save.grid(row=1, column=0, sticky="ew", padx=5, pady=5)
btn_underline.grid(row=2, column=0, sticky="ew", padx=5, pady=5)

fr_buttons.grid(row=0, column=0, sticky="ns")
txt_edit.grid(row=0, column=1, sticky="nsew")

window.mainloop()
