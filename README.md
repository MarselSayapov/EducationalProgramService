УрФУ Тестовое задание — Backend часть
Описание проекта
Данный проект — это тестовое задание, выполненное для УрФУ. Реализована полноценная Backend часть системы управления образовательными программами. Проект выполнен в стиле ONION архитектуры с разделением на слои и строгой инкапсуляцией бизнес-логики. Реализована базовая авторизация и CRUD операции для основных сущностей.

Стек технологий
.NET 8
C#
ASP.NET Core для разработки API
Entity Framework Core для работы с базой данных
Swagger для тестирования и документации API
ONION архитектура для четкого разделения слоев приложения
Основные возможности
Авторизация

Реализована базовая авторизация для защиты эндпоинтов.
Неавторизованные пользователи не могут выполнять CRUD операции.
CRUD операции:

Институты: Добавление, получение по Id, получение всех, удаление.
Образовательные программы: Добавление, обновление, получение по Id, получение всех, удаление.
Модули образовательных программ: Добавление, обновление, удаление.
Привязка модулей к образовательным программам: Добавление и удаление модулей из образовательных программ.
Архитектурные особенности:

Проект написан в соответствии с принципами ONION архитектуры, которая разделяет систему на несколько слоев:
Application: Интерфейсы и бизнес-логика.
Domain: Сущности и бизнес-правила.
Infrastructure: Реализация взаимодействия с базой данных (репозитории).
Services: Сервисы для работы с бизнес-логикой.
Это позволяет обеспечить высокую тестируемость, гибкость и поддержку модульности кода.
