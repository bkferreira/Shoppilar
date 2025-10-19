using Microsoft.Maui.Handlers;
#if ANDROID
using Android.Content.Res;
using Color = Android.Graphics.Color;
#endif

#if IOS
using UIKit;
#endif

namespace Shoppilar.Mobile.Handlers;

public static class CustomHandlers
{
    public static void Configure()
    {
        ConfigureEntry();
        ConfigureEditor();
        ConfigureDatePicker();
        ConfigureTimePicker();
        ConfigurePicker();
        ConfigureEntryDoneButton();
        ConfigureEditorDoneButton();
        ConfigureDatePickerDoneButton();
        ConfigureTimePickerDoneButton();
        ConfigurePickerDoneButton();
    }

    private static void ConfigureEntry()
    {
        EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList =
                ColorStateList.ValueOf(Color.Transparent);
#elif IOS
            handler.PlatformView.BorderStyle = UITextBorderStyle.None;
#endif
        });
    }

    private static void ConfigureEditor()
    {
#if ANDROID
        EditorHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
            handler.PlatformView.BackgroundTintList =
                ColorStateList.ValueOf(Color.Transparent);
        });
#endif
    }

    private static void ConfigureDatePicker()
    {
        DatePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList =
                ColorStateList.ValueOf(Color.Transparent);
#elif IOS
            handler.PlatformView.BorderStyle = UITextBorderStyle.None;
#endif
        });
    }

    private static void ConfigureTimePicker()
    {
        TimePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList =
                ColorStateList.ValueOf(Color.Transparent);
#elif IOS
            handler.PlatformView.BorderStyle = UITextBorderStyle.None;
#endif
        });
    }

    private static void ConfigurePicker()
    {
        PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList =
                ColorStateList.ValueOf(Color.Transparent);
#elif IOS
            handler.PlatformView.BorderStyle = UITextBorderStyle.None;
#endif
        });
    }

    private static void ConfigurePickerDoneButton()
    {
#if IOS
        PickerHandler.Mapper.AppendToMapping("CustomDoneButton", (handler, _) =>
        {
            if (handler.PlatformView.InputAccessoryView is UIToolbar toolbar)
            {
                var items = toolbar.Items?.ToList();
                if (items != null)
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var item = items[i];

                        if (item.Style == UIBarButtonItemStyle.Done)
                        {
                            var newButton =
 new UIBarButtonItem("Pronto", UIBarButtonItemStyle.Done, item.Target, item.Action);
                            items[i] = newButton;
                        }
                    }

                    toolbar.SetItems(items.ToArray(), false);
                    toolbar.SetNeedsLayout();
                }
            }
        });
#endif
    }

    private static void ConfigureTimePickerDoneButton()
    {
#if IOS
        TimePickerHandler.Mapper.AppendToMapping("CustomDoneButton", (handler, _) =>
        {
            if (handler.PlatformView.InputAccessoryView is UIToolbar toolbar)
            {
                var items = toolbar.Items?.ToList();
                if (items != null)
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var item = items[i];

                        if (item.Style == UIBarButtonItemStyle.Done)
                        {
                            var newButton =
 new UIBarButtonItem("Pronto", UIBarButtonItemStyle.Done, item.Target, item.Action);
                            items[i] = newButton;
                        }
                    }

                    toolbar.SetItems(items.ToArray(), false);
                    toolbar.SetNeedsLayout();
                }
            }
        });
#endif
    }

    private static void ConfigureDatePickerDoneButton()
    {
#if IOS
        DatePickerHandler.Mapper.AppendToMapping("CustomDoneButton", (handler, _) =>
        {
            if (handler.PlatformView.InputAccessoryView is UIToolbar toolbar)
            {
                var items = toolbar.Items?.ToList();
                if (items != null)
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var item = items[i];

                        if (item.Style == UIBarButtonItemStyle.Done)
                        {
                            var newButton =
 new UIBarButtonItem("Pronto", UIBarButtonItemStyle.Done, item.Target, item.Action);
                            items[i] = newButton;
                        }
                    }

                    toolbar.SetItems(items.ToArray(), false);
                    toolbar.SetNeedsLayout();
                }
            }
        });
#endif
    }

    private static void ConfigureEntryDoneButton()
    {
#if IOS
        EntryHandler.Mapper.AppendToMapping("CustomDoneButton", (handler, _) =>
        {
            if (handler.PlatformView.InputAccessoryView is UIToolbar toolbar)
            {
                var items = toolbar.Items?.ToList();
                if (items != null)
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var item = items[i];

                        if (item.Style == UIBarButtonItemStyle.Done)
                        {
                            var newButton =
 new UIBarButtonItem("Pronto", UIBarButtonItemStyle.Done, item.Target, item.Action);
                            items[i] = newButton;
                        }
                    }

                    toolbar.SetItems(items.ToArray(), false);
                    toolbar.SetNeedsLayout();
                }
            }
        });
#endif
    }

    private static void ConfigureEditorDoneButton()
    {
#if IOS
        EditorHandler.Mapper.AppendToMapping("CustomDoneButton", (handler, _) =>
        {
            if (handler.PlatformView.InputAccessoryView is UIToolbar toolbar)
            {
                var items = toolbar.Items?.ToList();
                if (items != null)
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        var item = items[i];

                        if (item.Style == UIBarButtonItemStyle.Done)
                        {
                            var newButton =
 new UIBarButtonItem("Pronto", UIBarButtonItemStyle.Done, item.Target, item.Action);
                            items[i] = newButton;
                        }
                    }

                    toolbar.SetItems(items.ToArray(), false);
                    toolbar.SetNeedsLayout();
                }
            }
        });
#endif
    }
}