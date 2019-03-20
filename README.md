# dt-utils

A set of Windows utilities for date and time manipulation.

Author: Vladimir Skach

Documentation: https://vladimir.skach.cz/dt-utils

# Command line utilities

# DtDate

Returns current date and time

https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings

Default: yyyy-MM-dd-HH-mm

  &gt; DtDate  
  2019-03-20-10-03  
  
  &gt; DtDate --format="{0:yyyy}-{0:MM}"  
  2019-03  
  
  &gt; DtDate --format="{0:HH}-{0:mm}"  
  10-12  


# DTlist

Lists files in directory with all times

&gt; DTlist  
created         accessed        modified        filename  
2019-03-20 10:02:42     2019-03-20 10:02:42     2019-03-20 10:16:40     DtDate.exe  
2019-03-19 10:53:29     2019-03-19 10:53:29     2019-03-19 11:04:02     DtGUI.exe  
2019-03-19 10:53:29     2019-03-19 10:53:29     2019-03-19 9:58:47      DtGUI.exe.config  
2019-03-19 10:53:29     2019-03-19 10:53:29     2019-03-19 11:04:02     DtGUI.pdb  
2019-03-19 11:05:04     2019-03-19 11:05:04     2019-03-19 9:57:36      DtLib.dll  
2019-03-20 10:19:49     2019-03-20 10:19:49     2019-03-20 10:19:35     Dtlist.exe  

# DTsetdate

Set date(s) for specific file

&gt; Dtlist.exe C:\i  
Created                 Accessed                Modified                Filename  
2019-03-20 11:01:55     2019-03-20 11:01:55     2019-03-20 11:01:57     testfile.txt  
  
>Dtsetdate.exe "C:\i\testfile.txt" "2018-01-01" -set=c  
  
&gt; Dtlist.exe C:\i  
Created                 Accessed                Modified                Filename  
2018-01-01 0:00:00      2019-03-20 11:01:55     2019-03-20 11:01:57     testfile.txt  

&gt; Dtsetdate.exe "C:\i\testfile.txt" "2016-10-01 12:34:56" -set=acm  
  
&gt; Dtlist.exe C:\i  
Created                 Accessed                Modified                Filename  
2016-10-01 12:34:56     2016-10-01 12:34:56     2016-10-01 12:34:56     testfile.txt  
  
#DTsetdir

Set date(s) for files in directory
  
&gt; Dtlist.exe c:\i  
Created                 Accessed                Modified                Filename  
2016-10-01 12:34:56     2016-10-01 12:34:56     2016-10-01 12:34:56     testfile1.txt  
2019-03-20 11:12:45     2019-03-20 11:12:45     2019-03-20 11:12:46     testfile2.txt  
2019-03-20 11:13:00     2019-03-20 11:13:00     2019-03-20 11:13:01     testfile3.txt  
  
&gt; DtSetdir "C:\i" "*.*" "2016-07-08 10:00:00" -set=acm  
  
&gt; Dtlist c:\i  
Created                 Accessed                Modified                Filename  
2016-07-08 10:00:00     2016-07-08 10:00:00     2016-07-08 10:00:00     testfile1.txt  
2016-07-08 10:00:00     2016-07-08 10:00:00     2016-07-08 10:00:00     testfile2.txt  
2016-07-08 10:00:00     2016-07-08 10:00:00     2016-07-08 10:00:00     testfile3.txt  
  
&gt; DtSetdir "C:\i" "*.*" "2016-07-08 10:00:00" -set=acm -offset=+5s  
  
&gt; Dtlist c:\i  
Created                 Accessed                Modified                Filename  
2016-07-08 10:00:00     2016-07-08 10:00:00     2016-07-08 10:00:00     testfile1.txt  
2016-07-08 10:00:05     2016-07-08 10:00:05     2016-07-08 10:00:05     testfile2.txt  
2016-07-08 10:00:10     2016-07-08 10:00:10     2016-07-08 10:00:10     testfile3.txt  
  
# DTsetdir  
  
GUI application with the same ability as DTsetdir 
