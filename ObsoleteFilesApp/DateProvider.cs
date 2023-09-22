namespace ObsoleteFilesApp;

class DateProvider : IDateProvider
{
  public DateTime GetCurrentDateTime() => DateTime.Now;
}