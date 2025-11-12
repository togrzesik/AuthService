# 🔐 AuthService — Example of OOP and Design Patterns in C#

This project is a simple authentication service written in **C# (.NET 8)**.  
It demonstrates clean code practices, **SOLID principles**, and several **design patterns** used in enterprise software.

---

## 🚀 Project Overview

`AuthService` simulates a basic user authentication system that validates login credentials based on configurable rules (e.g. password length, digits, special characters).

The goal of this project is **to showcase understanding of Object-Oriented Programming (OOP)**, and **common design patterns** in a realistic, maintainable way.

## 🧠 Architecture Overview

The system consists of several key components:

| Layer | Responsibility | Design Pattern |
|-------|----------------|----------------|
| `AuthConfiguration` | Stores global authentication rules | Singleton |
| `User` | Represents user credentials | Builder |
| `AuthHandler` | Abstract validation chain | Chain of Responsibility |
| `AuthService` | Coordinates authentication flow | Uses handlers and configuration |

## Example Output

🔍 Validating credentials...

✅ Authentication successful! Welcome john.doe@example.com


--- Incorrect login attempt ---
❌ Username must be an email address.
❌ Password must be at least 8 characters long.
❌ Authentication failed.
