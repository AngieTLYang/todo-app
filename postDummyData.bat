@echo off
setlocal

:: Set API endpoint and content type
set URL=http://localhost:5144/api/todo
set HEADER=Content-Type: application/json

:: Post dummy todo items (no "note" field)
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Buy groceries\",\"isDone\":false,\"enter_date\":\"2025-05-31\",\"deadline\":\"2025-06-01\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Walk the dog\",\"isDone\":true,\"enter_date\":\"2025-05-30\",\"deadline\":\"2025-05-30\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Call mom\",\"isDone\":false,\"enter_date\":\"2025-05-29\",\"deadline\":\"2025-06-02\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Read a book\",\"isDone\":false,\"enter_date\":\"2025-05-28\",\"deadline\":\"2025-06-10\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Finish project\",\"isDone\":false,\"enter_date\":\"2025-05-27\",\"deadline\":\"2025-06-05\"}"

endlocal
pause