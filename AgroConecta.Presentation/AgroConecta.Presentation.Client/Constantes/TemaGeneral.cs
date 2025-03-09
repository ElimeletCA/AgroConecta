using MudBlazor;

namespace AgroConecta.Presentation.Client.Constantes;

public class TemaGeneral : MudTheme
{
    public TemaGeneral()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = Colors.Green.Default,
            Secondary = Colors.Brown.Lighten1,
            Tertiary = Colors.Gray.Lighten1,
            AppbarBackground = Colors.Shades.White,
        };
        PaletteDark = new PaletteDark()
        {
            Primary = Colors.Green.Lighten2
        };
        Typography = new Typography()
        {
            Default = new Default()
            {
                FontFamily = new[] { "Inter", "sans-serif" }
            }
        };

        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px",
        };
    }
}