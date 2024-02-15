using Autodesk.AutoCAD.Internal.PropertyInspector;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Autodesk.AutoCAD.ActivistInvestor
{
   public static class PropertyInspector
   {
      static IAcPpPaletteSet paletteSet = null;

      public static IAcPpPaletteSet PaletteSet
      {
         get
         {
            if(paletteSet == null)
               paletteSet = (IAcPpPaletteSet)new AcPpPaletteSetClass();
            return paletteSet;
         }
      }

      public static bool Visible
      {
         get
         {
            return PaletteSet.Visibility;
         }
         set
         {
            if(value ^ PaletteSet.Visibility)
               PaletteSet.Visibility = value;
         }
      }

      public static PropertyInspectorEventManager EventManager
      {
         get
         {
            return PropertyInspectorEventManager.Instance();
         }
      }
   }

}

[ComImport]
[Guid("A20A927F-5508-4624-9157-FD5CBE5B2D64")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IAcPpPalette
{
   [DispId(1)]
   string Name
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [param: In]
      [param: MarshalAs(UnmanagedType.BStr)]
      set;
   }
}


[ComImport]
[Guid("0CC0CED7-7D69-490B-A84B-A7500674A29C")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

public interface IAcPpPaletteSet
{
   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void AddPalette([In][MarshalAs(UnmanagedType.Interface)] IAcPpPalette pPalette);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void DeletePalette([In][MarshalAs(UnmanagedType.Interface)] IAcPpPalette pPalette);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void InsertPalette([In] int index, [In][MarshalAs(UnmanagedType.Interface)] IAcPpPalette pPalette);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   [return: MarshalAs(UnmanagedType.Interface)]
   IAcPpPalette GetPalette([In] int index);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   [return: MarshalAs(UnmanagedType.Interface)]
   IAcPpPalette GetPaletteByName([In][MarshalAs(UnmanagedType.BStr)] string paletteName);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void ActivatePalette([In][MarshalAs(UnmanagedType.Interface)] IAcPpPalette pPalette);

   [DispId(7)]
   int PaletteCount
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      get;
   }

   [DispId(8)]
   bool Visibility
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [param: In]
      set;
   }

   [DispId(9)]
   int CurrentIndex
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      get;
   }

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void GetDockingState(out int nDockPos, out int left, out int top, out int width, out int height);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void SetDockingState([In] int nDockPos, [In] int left, [In] int top, [In] int width, [In] int height);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void GetFloatingRect(out int left, out int top, out int width, out int height);

   [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
   void GetDockingRect(out int nDockPos, out int left, out int top, out int width, out int height);
}


[ComImport]
[ClassInterface(ClassInterfaceType.None)]
[ComSourceInterfaces("Autodesk.AutoCAD.PropertyPalette.IAcPpPaletteSetEvents\0")]
[Guid("2FAA8BEA-AB1B-479A-97B2-6E7AAB38750E")]
[TypeLibType(TypeLibTypeFlags.FCanCreate)]
public class AcPpPaletteSetClass
{
}

