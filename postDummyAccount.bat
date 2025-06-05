@echo off
setlocal

:: Set API endpoint and content type
set URL=http://localhost:5144/api/account
set HEADER=Content-Type: application/json

:: Post dummy account items
curl -X POST %URL% -H "%HEADER%" -d "{\"username\":\"alice\",\"email\":\"alice@example.com\",\"passwordHash\":\"ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f\",\"createdAt\":\"2025-05-31T00:00:00Z\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"username\":\"bob\",\"email\":\"bob@example.com\",\"passwordHash\":\"84c4e92f676a4b4326bb68108cf1bc9947d7d5b3be03ce2461a872e397750b19\",\"createdAt\":\"2025-05-30T00:00:00Z\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"username\":\"carol\",\"email\":\"carol@example.com\",\"passwordHash\":\"3b3fdc05ff54ea0228669e02cdb65f2d7207e70b1e62a24b5a0b26dd2d0a7e1d\",\"createdAt\":\"2025-05-29T00:00:00Z\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"username\":\"dave\",\"email\":\"dave@example.com\",\"passwordHash\":\"73399cd60d8e740c36bc51d030bfc918a649c5de62f2fe979dce1d51f0613b08\",\"createdAt\":\"2025-05-28T00:00:00Z\"}"

curl -X POST %URL% -H "%HEADER%" -d "{\"username\":\"eve\",\"email\":\"eve@example.com\",\"passwordHash\":\"ada13168883c61d4c3312317464b13ea3ad38d9d8f5d99cba5f6826eb57ddf3a\",\"createdAt\":\"2025-05-27T00:00:00Z\"}"

endlocal
pause
