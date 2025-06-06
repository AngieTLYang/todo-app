@echo off
setlocal

:: Set API endpoint and content type
set URL=http://localhost:5144/api/todo
set HEADER=Content-Type: application/json

:: === AccountId 1 ===
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Do laundry\",\"isDone\":false,\"enter_date\":\"2025-06-01\",\"deadline\":\"2025-06-02\",\"accountId\":1}"
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Submit report\",\"isDone\":false,\"enter_date\":\"2025-06-01\",\"deadline\":\"2025-06-03\",\"accountId\":1}"

:: === AccountId 2 ===
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Prepare slides\",\"isDone\":true,\"enter_date\":\"2025-05-31\",\"deadline\":\"2025-06-01\",\"accountId\":2}"
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Reply emails\",\"isDone\":false,\"enter_date\":\"2025-05-30\",\"deadline\":\"2025-06-02\",\"accountId\":2}"

:: === AccountId 3 ===
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Jog in park\",\"isDone\":false,\"enter_date\":\"2025-05-29\",\"deadline\":\"2025-06-01\",\"accountId\":3}"
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Water plants\",\"isDone\":true,\"enter_date\":\"2025-05-28\",\"deadline\":\"2025-05-30\",\"accountId\":3}"

:: === AccountId 4 ===
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Buy birthday gift\",\"isDone\":false,\"enter_date\":\"2025-05-27\",\"deadline\":\"2025-06-04\",\"accountId\":4}"
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Clean room\",\"isDone\":false,\"enter_date\":\"2025-05-26\",\"deadline\":\"2025-06-01\",\"accountId\":4}"

:: === AccountId 5 ===
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Fix bike\",\"isDone\":false,\"enter_date\":\"2025-05-25\",\"deadline\":\"2025-06-02\",\"accountId\":5}"
curl -X POST %URL% -H "%HEADER%" -d "{\"task\":\"Schedule dentist\",\"isDone\":true,\"enter_date\":\"2025-05-24\",\"deadline\":\"2025-06-03\",\"accountId\":5}"

endlocal
pause
