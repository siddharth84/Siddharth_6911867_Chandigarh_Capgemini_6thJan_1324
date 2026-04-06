# Order Management System — Setup Guide
## A learning project: ASP.NET Core Web API + MVC + EF Core + JWT + DI

---

## WHAT YOU NEED INSTALLED FIRST

1. **Visual Studio 2022** (Community — free)
   - Download: https://visualstudio.microsoft.com/vs/community/
   - During install, select the workload: "ASP.NET and web development"

2. **SQL Server Express** (free) — for the database
   - Download: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
   - Choose "Express" edition
   - OR: If you installed Visual Studio with the ASP.NET workload, you likely
     already have **SQL Server LocalDB** — no extra install needed!

3. **.NET 8 SDK** — usually installed with Visual Studio automatically
   - Check by opening Command Prompt and typing: dotnet --version
   - Should show 8.x.x

---

## HOW TO OPEN THE PROJECT

1. Extract the zip file anywhere (e.g. C:\Projects\OrderSolution)
2. Double-click **OrderSolution.sln**
3. Visual Studio opens with 3 projects:
   - **OrderApi**      — the backend Web API
   - **OrderMvc**      — the frontend website
   - **OrderApi.Tests** — unit tests

---

## ONE-TIME SETUP: FIX THE MVC PORT NUMBER

The MVC frontend needs to know what port the API is running on.

1. In Solution Explorer, right-click **OrderApi** → Properties
2. Go to **Debug** → **Open debug launch profiles UI**
3. Note the **App URL** (e.g. https://localhost:7001)
4. Open **OrderMvc → Program.cs**
5. Find this line and update the port to match:
   ```
   client.BaseAddress = new Uri("https://localhost:7001/");
   ```
   Change 7001 to whatever port your OrderApi uses.

---

## HOW TO RUN

### Option A — Run both projects at once (recommended)

1. Right-click the **Solution** (top item in Solution Explorer) → **Properties**
2. Go to **Startup Project** → select **"Multiple startup projects"**
3. Set both **OrderApi** and **OrderMvc** to **"Start"**
4. Click OK
5. Press **F5** — two browser windows open automatically

### Option B — Run just the API (to test with Swagger)

1. Right-click **OrderApi** → **Set as Startup Project**
2. Press **F5**
3. Swagger UI opens — test all endpoints there

---

## THE DATABASE IS CREATED AUTOMATICALLY

When the API starts for the first time, it automatically:
- Creates the database (called **OrderDb**)
- Creates all tables (Users, Orders, Products, Categories, etc.)
- Seeds starter data:
  - Users: Alice (Id=1), Bob (Id=2)
  - Products: Laptop ($999.99), Mouse ($29.99), Keyboard ($79.99)
  - Categories: Electronics, Accessories

**You do NOT need to run any migration commands manually.**

---

## TEST ACCOUNTS

| Username | Password | Role  | Can do                          |
|----------|----------|-------|---------------------------------|
| user     | user123  | User  | Place orders, view orders       |
| admin    | admin123 | Admin | Add products (via Swagger/API)  |

---

## HOW TO USE THE APP

### Via the MVC Website:
1. Go to the MVC URL (e.g. https://localhost:7002)
2. Click **"Login & Place Order"**
3. Enter: username = `user`, password = `user123`
4. You'll be logged in and can place orders
5. Click **"View All Orders"** to see orders in the database
6. Click **"View Products"** to see the cache demo (first load = database, refresh = cache)

### Via Swagger (API directly):
1. Go to the API URL (e.g. https://localhost:7001)
2. Swagger UI opens automatically
3. **Step 1**: Click **POST /api/auth/login** → Try it out → Enter:
   ```json
   { "username": "user", "password": "user123" }
   ```
4. **Step 2**: Copy the `token` value from the response
5. **Step 3**: Click the **Authorize** button (top right, lock icon)
6. Paste the token → click Authorize → Close
7. Now all protected endpoints are unlocked — try them!

---

## ENDPOINTS REFERENCE

### Auth
| Method | URL               | Who    | What                  |
|--------|-------------------|--------|-----------------------|
| POST   | /api/auth/login   | Anyone | Get JWT token         |

### Orders (requires login)
| Method | URL               | Who        | What                  |
|--------|-------------------|------------|-----------------------|
| GET    | /api/orders       | Any user   | Get all orders        |
| GET    | /api/orders/{id}  | Any user   | Get one order         |
| POST   | /api/orders       | Role=User  | Place a new order     |

### Products
| Method | URL                    | Who        | What                  |
|--------|------------------------|------------|-----------------------|
| GET    | /api/products          | Anyone     | Get products (cached) |
| POST   | /api/products/add      | Role=Admin | Add a product         |

---

## RUNNING THE UNIT TESTS

1. In Visual Studio: **Test** menu → **Run All Tests**
2. Or use shortcut: **Ctrl+R, A**
3. The Test Explorer panel shows results — all 5 tests should pass
4. These tests use **Moq** to fake the database — no real DB needed for tests

---

## COMMON ERRORS & FIXES

**Error: "Unable to connect to database"**
- Make sure SQL Server or LocalDB is installed
- Check the connection string in OrderApi/appsettings.json:
  ```
  "Server=(localdb)\\mssqllocaldb;Database=OrderDb;Trusted_Connection=True;"
  ```
- If using full SQL Server instead of LocalDB, change to:
  ```
  "Server=localhost;Database=OrderDb;Trusted_Connection=True;TrustServerCertificate=True;"
  ```

**Error: 401 Unauthorized**
- You forgot to add the token in Swagger
- Login at /api/auth/login first, copy the token, click Authorize

**Error: 403 Forbidden**
- You're using the wrong role
- Admin cannot place orders → use user/user123 for orders
- User cannot add products → use admin/admin123 for products

**Error: "This site can't be reached" on MVC**
- The port in OrderMvc/Program.cs doesn't match the API port
- Check and fix as described in the setup step above

**Error: SSL certificate warning in browser**
- Click "Advanced" → "Proceed anyway" — this is normal for local development

---

## PROJECT STRUCTURE EXPLAINED

```
OrderSolution/
├── OrderApi/                    ← The Web API (backend)
│   ├── Controllers/             ← HTTP endpoints (what the client calls)
│   │   ├── AuthController.cs    ← Login → get token
│   │   ├── OrdersController.cs  ← CRUD for orders
│   │   └── ProductsController.cs← Products with caching demo
│   ├── Data/
│   │   └── AppDbContext.cs      ← EF Core database context
│   ├── Mapping/
│   │   └── MappingProfile.cs    ← AutoMapper: DTO ↔ Entity
│   ├── Middleware/
│   │   └── ExceptionMiddleware.cs ← Catches all unhandled errors
│   ├── Migrations/              ← EF Core auto-generated DB schema
│   ├── Models/
│   │   ├── Entities.cs          ← Database tables as C# classes
│   │   └── DTOs.cs              ← What the API sends/receives
│   ├── Repositories/            ← Database access layer
│   ├── Services/                ← Business logic layer
│   ├── Validators/              ← FluentValidation rules
│   ├── appsettings.json         ← Config (DB connection, JWT key)
│   └── Program.cs               ← App startup + all DI registrations
│
├── OrderMvc/                    ← The MVC website (frontend)
│   ├── Controllers/
│   │   ├── HomeController.cs
│   │   └── OrderController.cs   ← Calls the API via HttpClient
│   └── Views/
│       ├── Home/Index.cshtml    ← Landing page
│       ├── Order/Login.cshtml   ← Login form
│       ├── Order/Create.cshtml  ← Place order form
│       ├── Order/Orders.cshtml  ← View all orders
│       ├── Order/Products.cshtml← Products + cache demo
│       └── Order/Success.cshtml ← Order confirmation
│
├── OrderApi.Tests/              ← Unit tests (xUnit + Moq)
│   └── OrderServiceTests.cs     ← 5 tests for OrderService
│
└── OrderSolution.sln            ← Open this in Visual Studio
```

---

## KEY CONCEPTS THIS PROJECT DEMONSTRATES

| Concept              | Where to see it                                      |
|----------------------|------------------------------------------------------|
| Dependency Injection | Program.cs → AddScoped/AddSingleton/AddTransient     |
| Repository Pattern   | Repositories/ folder                                 |
| Service Layer        | Services/ folder                                     |
| JWT Authentication   | AuthController + Program.cs JWT setup                |
| Role Authorization   | [Authorize(Roles = "Admin")] on controllers          |
| AutoMapper           | Mapping/MappingProfile.cs + controllers              |
| FluentValidation     | Validators/Validators.cs                             |
| EF Core + Relations  | Data/AppDbContext.cs + Models/Entities.cs            |
| Caching              | ProductsController.cs (IMemoryCache demo)            |
| Global Error Handler | Middleware/ExceptionMiddleware.cs                    |
| Unit Testing         | OrderApi.Tests/OrderServiceTests.cs                  |
| Swagger + JWT        | Program.cs AddSwaggerGen + Authorize button          |
