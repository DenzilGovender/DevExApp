// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DevExMobileApp.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

        #region Setting Constants

    private const string userID_key = "user_ID";
    private static readonly string userID_value = string.Empty;

    private const string first_name_key = "first_name";
    private static readonly string first_name_value = string.Empty;

    private const string surname_key = "surname";
    private static readonly string surname_value = string.Empty;

    private const string email_key = "email";
    private static readonly string email_value = string.Empty;

    private const string registered_key = "isregistered";
    private static readonly string registered_value = string.Empty;

    private const string scannedkudos_key = "iskudosscanned";
    private static readonly string scannedkudos_value = string.Empty;

        #endregion

        public static string UserID
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(userID_key, userID_value);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(userID_key, value);
            }

        }

        public static string Firstname
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(first_name_key, first_name_value);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(first_name_key, value);
      }
      
    }

        public static string Surname
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(surname_key, surname_value);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(surname_key, value);
            }

        }

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(email_key, email_value);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(email_key, value);
            }

        }


        public static string RegisteredDate
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(registered_key, registered_value);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(registered_key, value);
            }

        }

        public static string ScannedKudosDate
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(scannedkudos_key, scannedkudos_value);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(scannedkudos_key, value);
            }

        }

    }
}