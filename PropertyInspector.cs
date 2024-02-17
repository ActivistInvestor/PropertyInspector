using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.Internal.PropertyInspector;

namespace Autodesk.AutoCAD.ActivistInvestor
{
   public static class PropertyInspector
   {
      static IAcPpPaletteSet paletteSet = null;

      /// <summary>
      /// The properties PaletteSet
      /// </summary>
      
      public static IAcPpPaletteSet PaletteSet
      {
         get
         {
            if(paletteSet == null)
               paletteSet = (IAcPpPaletteSet)new AcPpPaletteSetClass();
            return paletteSet;
         }
      }

      /// <summary>
      /// Gets/Sets the visibility of the Properties Palette.
      /// 
      /// Note: Showing or hiding a docked palette set will cause
      /// any currently-executing command(s) to be cancelled.
      /// For that reason, changing this property's value from a
      /// running command is not recommended.
      /// </summary>

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

      /// <summary>
      /// The event manger that provides access to events
      /// exposed by the IAcPpPaletteSet interface.
      /// </summary>
      
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

/// <summary>
/// An instance of this interface is passed into the handlers
/// of events exposed by the EventManager
/// </summary>
[ComImport]
[Guid("B2BB79F7-06BD-42FB-814F-EFD656C1698C")]
[TypeLibType(4160)]
public interface IAcPiPropertyIdentifier
{
   [DispId(1)]
   string Name
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(1)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(1)]
      [param: In]
      [param: MarshalAs(UnmanagedType.BStr)]
      set;
   }

   [DispId(2)]
   ushort Type
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(2)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(2)]
      [param: In]
      set;
   }

   [DispId(3)]
   Guid ControlCLSID
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(3)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(3)]
      [param: In]
      set;
   }

   [DispId(4)]
   object Value
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(4)]
      [return: MarshalAs(UnmanagedType.Struct)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(4)]
      [param: In]
      [param: MarshalAs(UnmanagedType.Struct)]
      set;
   }

   [DispId(5)]
   string Categories
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(5)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(5)]
      [param: In]
      [param: MarshalAs(UnmanagedType.BStr)]
      set;
   }

   [DispId(6)]
   string ValueAsString
   {
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(6)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [DispId(6)]
      [param: In]
      [param: MarshalAs(UnmanagedType.BStr)]
      set;
   }
}

[ComImport]
[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(2)]
[Guid("8B049801-6BC7-46E5-AA22-95AEA239BE54")]
public class AcPiPropertyIdentifierClass
{
}

