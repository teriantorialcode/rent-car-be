
## Backend Setup (API - .NET)

### 1. **Clone Repository**
   - Clone repository backend ke dalam lokal Anda:
     ```bash
     git clone https://github.com/teriantorialcode/rent-car-be.git
     cd rent-car-be
     ```

### 2. **Install Dependencies**
   - Pastikan Anda sudah menginstal **.NET SDK**. Saya memakai .net 7. Silakan mengunduhnya [di sini](https://dotnet.microsoft.com/download).
   - Jalankan perintah berikut untuk menginstal semua dependencies:
     ```bash
     dotnet restore
     ```

### 3. **Set up PostgreSQL Database**
   - Pastikan Anda sudah menginstal PostgreSQL dan membuat database.
   - Konfigurasi file `appsettings.json` untuk koneksi ke database PostgreSQL. 
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Host=localhost;Port=5432;Database=rentcar;Username=your_username;Password=your_password"
       }
     }
     ```
   
   - **Catatan**: Pastikan PostgreSQL berjalan dan database `rentcar` sudah ada.

### 4. **Migrate Database**
   - Jalankan migration untuk membuat tabel di database:
     ```bash
     dotnet ef database update
     ```

### 5. **Run Backend API**
   - Jalankan API menggunakan perintah berikut:
     ```bash
     dotnet run
     ```
   - API backend akan berjalan di `https://localhost:7127`.


### Architecture Design

+-----------------+     API Requests/Responses (JSON)     +--------------------+     SQL Queries/Results              +---------------------------+
|  Vue 3 Frontend  |------------------------------------->|  .NET API Backend  |------------------------------------->| PostgreSQL Database       |
| (Browser)        |                                      |        C#          |                                      | (car,booking data Store)  |
+-----------------+                                       +--------------------+                                      +---------------------------+
     ^                                                              |
     |                                                              |
     +--------------------------------------------------------------+
                      Data Flow (e.g., Car Data, Booking Rent data)
---
