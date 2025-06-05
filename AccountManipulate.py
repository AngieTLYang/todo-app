import sqlite3
from datetime import datetime
import os

# Get the absolute directory where the script resides
script_dir = os.path.dirname(os.path.abspath(__file__))

# Build full path to the database file relative to the script directory
db_path = os.path.join(script_dir, "todo.db")
print("Using database at:", db_path)

# Connect using the full path
conn = sqlite3.connect(db_path)
cursor = conn.cursor()

# cursor.execute('DROP TABLE IF EXISTS Accounts')

# Create Account table if it does not exist
cursor.execute('''
CREATE TABLE IF NOT EXISTS Accounts (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL,
    Email TEXT NOT NULL,
    PasswordHash TEXT NOT NULL,
    CreatedAt TEXT NOT NULL
)
''')

# Function to print all entries in Account table
def print_all_accounts():
    cursor.execute('SELECT Id, Username, Email, PasswordHash, CreatedAt FROM Accounts')
    rows = cursor.fetchall()
    if not rows:
        print("No accounts found.")
    else:
        for row in rows:
            print(f"Id: {row[0]}, Username: {row[1]}, Email: {row[2]}, PasswordHash: {row[3]}, CreatedAt: {row[4]}")

print_all_accounts()

# Close connection
conn.close()
