using SheetMusicLib.Models;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Services
{
    public class ThemeService
    {
        private readonly DbContextOptions<RamLibContext> _options;

        public ThemeService(DbContextOptions<RamLibContext> options)
        {
            _options = options;
        }

        public async Task<Theme?> GetCurrentThemeAsync()
        {
            // Retrieve the selected theme ID from the SETTINGS table
            using (var context = new RamLibContext(_options))
            {
                var setting = await context.Settings.FirstOrDefaultAsync(s => s.sSettingKey == "ThemeId");
                int themeId = 1; // Default theme
                if (setting != null)
                {
                    themeId = int.Parse(setting.sSettingValue);
                }
                return await context.Themes.FindAsync(themeId);
            }
        }
    }
}
