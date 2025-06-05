import sqlite3
import os
# Get the absolute directory where the script resides
script_dir = os.path.dirname(os.path.abspath(__file__))

# Build full path to the database file relative to the script directory
db_path = os.path.join(script_dir, "todo.db")

print("Using database at:", db_path)

# Connect using the full path
conn = sqlite3.connect(db_path)
cursor = conn.cursor()

cursor.execute("SELECT name FROM sqlite_master WHERE type='table';")
tables = cursor.fetchall()
print("Existing tables in database:")
for table in tables:
    print(table[0])

# Print schema
cursor.execute(f"PRAGMA table_info({"ToDoItems"});")
schema = cursor.fetchall()
print("Columns:")
for col in schema:
    col_id, name, col_type, notnull, default_value, pk = col
    print(f"  {name} ({col_type}) {'PRIMARY KEY' if pk else ''}")
'''
# Step 1: Drop the existing table if it exists
cursor.execute("DROP TABLE IF EXISTS ToDoItems")

# Step 2: Create the new table with additional fields
cursor.execute("""
CREATE TABLE ToDoItems (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    task TEXT NOT NULL,
    isDone BOOLEAN NOT NULL,
    enter_date TEXT,     -- ISO format like '2025-05-31'
    deadline TEXT       -- ISO format or any format you prefer
)
""")
'''
cursor.execute("SELECT * FROM ToDoItems;")
rows = cursor.fetchall()
print("Rows in ToDoItems after reset:", rows)

# Commit and close connection
conn.commit()
conn.close()
