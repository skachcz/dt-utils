# dt-utils

A set of Windows utilities for date and time manipulation.

# Command line utilities


#DtDate

Returns current date and time

https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings

Default: yyyy-MM-dd-HH-mm

>DtDate
2019-03-20-10-03

>DtDate --format="{0:yyyy}-{0:MM}"
2019-03

>DtDate --format="{0:HH}-{0:mm}"
10-12


#DTlist

Lists files in directory with all times

C:\winapps\dt-utils>DTlist
created         accessed        modified        filename
2019-03-20 10:02:42     2019-03-20 10:02:42     2019-03-20 10:16:40     DtDate.exe
2019-03-19 10:53:29     2019-03-19 10:53:29     2019-03-19 11:04:02     DtGUI.exe
2019-03-19 10:53:29     2019-03-19 10:53:29     2019-03-19 9:58:47      DtGUI.exe.config
2019-03-19 10:53:29     2019-03-19 10:53:29     2019-03-19 11:04:02     DtGUI.pdb
2019-03-19 11:05:04     2019-03-19 11:05:04     2019-03-19 9:57:36      DtLib.dll
2019-03-20 10:19:49     2019-03-20 10:19:49     2019-03-20 10:19:35     Dtlist.exe



