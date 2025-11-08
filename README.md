# 📖 DiaryApp - Your Personal Journaling Space

A beautiful, modern web application for keeping track of your thoughts, memories, and daily reflections. Built with ASP.NET Core MVC and designed with a focus on user experience and visual appeal.

Demo :
http://diaryentries.runasp.net/DiaryEnteries

## ✨ Features

- **📝 Create & Manage Entries** - Write diary entries with title, mood, and detailed descriptions
- **😊 Mood Tracking** - Track your emotional state with 6 different moods (Happy, Sad, Excited, Calm, Anxious, Grateful)
- **🔍 Smart Search & Filters** - Search entries by keywords and filter by mood or date
- **📊 Pagination** - Clean pagination for easy navigation (10 entries per page)
- **🎨 Beautiful UI** - Modern, gradient-based design with smooth animations
- **📱 Fully Responsive** - Works perfectly on desktop, tablet, and mobile devices
- **✅ Form Validation** - Client-side and server-side validation with helpful error messages
- **🎯 Character Counter** - Track your writing progress in real-time
- **⏰ Auto-timestamps** - Automatic date and time recording for each entry
- **🔄 Auto-cleanup** - Background service that cleans database every 2 hours and re-seeds with sample data

## 🛠️ Tech Stack

- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: SQL Server with Entity Framework Core
- **Frontend**: 
  - HTML5, CSS3, JavaScript
  - Bootstrap 5
  - jQuery
  - Font Awesome 6
- **Validation**: jQuery Unobtrusive Validation
- **Background Services**: IHostedService for automated database cleanup

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or Developer Edition)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/DiaryApp.git
   cd DiaryApp
   ```

2. **Update the connection string**
   
   Open `appsettings.json` and update the connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DiaryAppDB;Trusted_Connection=true;"
     }
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open your browser**
   
   Navigate to `https://localhost:5001` or `http://localhost:5000`

## 📁 Project Structure

```
DiaryApp/
├── Controllers/
│   ├── HomeController.cs
│   ├── DiaryEnteriesController.cs
│   └── ErrorController.cs
├── Models/
│   ├── DiaryEntry.cs
│   └── Mood.cs (Enum)
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── About.cshtml
│   │   └── Privacy.cshtml
│   ├── DiaryEnteries/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   ├── Error/
│   │   └── Error404.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── Data/
│   └── ApplicationDbContext.cs
├── Services/
│   └── DatabaseCleanupService.cs
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
├── appsettings.json
└── Program.cs
```

## 🎨 Design Highlights

- **Gradient Color Scheme**: Purple and pink gradients throughout for a modern look
- **Smooth Animations**: Fade-in, slide, and hover effects for better UX
- **Glassmorphism**: Frosted glass effects on navbar and cards
- **Mood Visualizations**: Emoji-based mood tracking with animated selection
- **Responsive Grid**: Auto-adjusting layouts for all screen sizes

## 💾 Database Schema

### DiaryEntry Table
| Column      | Type     | Description                    |
|-------------|----------|--------------------------------|
| Id          | int      | Primary key                    |
| Title       | string   | Entry title (required)         |
| Description | string   | Entry content (required)       |
| Created     | DateTime | Timestamp (auto-generated)     |
| Mood        | int      | Mood enum (0-5)               |

### Mood Enum Values
- 0: Happy 😊
- 1: Sad 😢
- 2: Excited 🤩
- 3: Calm 😌
- 4: Anxious 😰
- 5: Grateful 🙏

## 🔧 Configuration

### Database Cleanup Service

The app includes a background service that automatically cleans the database every 2 hours. Configure it in `appsettings.json`:

```json
{
  "DatabaseCleanup": {
    "Enabled": true,
    "IntervalHours": 2
  }
}
```

To disable automatic cleanup, set `Enabled` to `false`.

## 🎯 Key Features Explained

### Pagination
- Shows 10 entries per page
- Smart page number display (e.g., 1 ... 5 6 7 ... 20)
- Maintains filters across page changes

### Search & Filter
- Real-time search with 800ms debounce
- Filter by mood (6 options)
- Sort by date (newest/oldest) or title (A-Z/Z-A)
- Active filter tags show current filters

### Validation
- Client-side validation using jQuery Unobtrusive
- Server-side validation in controllers
- Error messages with icons
- Red borders on invalid fields
- Auto-scroll to first error

## 🐛 Known Issues

- None at the moment! 🎉

## 🚀 Future Enhancements

- [ ] User authentication and authorization
- [ ] Export entries to PDF
- [ ] Dark mode toggle
- [ ] Rich text editor for descriptions
- [ ] Image attachments
- [ ] Tags and categories
- [ ] Search by date range
- [ ] Mood analytics dashboard
- [ ] Email notifications

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 👨‍💻 Author

**Your Name**
- GitHub: [@salova-patchi](https://github.com/salova-patchi))
- Email: ismail.boureghda2003@gmail.com

## 🙏 Acknowledgments

- Font Awesome for the beautiful icons
- Bootstrap team for the responsive framework
- The ASP.NET Core community for excellent documentation
- Everyone who believes in the power of journaling!

## 📸 Links

### Home Page
[![Home Page]](http://diaryentries.runasp.net/Home/)

### Diary Entries List
[![Entries List]](http://diaryentries.runasp.net/DiaryEnteries)

### Create Entry Form
[![Create Form]](http://diaryentries.runasp.net/DiaryEnteries/Create)

### Entry Details
[![Details Page](http://diaryentries.runasp.net/DiaryEnteries/Details/428)

---

⭐ **If you like this project, please give it a star!** ⭐

Made with ❤️ and lots of ☕
