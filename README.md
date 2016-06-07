# RawPrintService
This is an ASPNet Core wrapper for https://github.com/tonyedgecombe/RawPrint

It should be installed as a Windows service using sc.exe:

sc create RawPrint binPath= (path to published binaries) (options)

By default it runs on port 6801. You can change it editing the hosting.json file

The service requieres a ESC/P or other raw-capable printer installed. The used printer is configured on the AppSettings.json file.

A client program need to make a POST request to /api/printer. The request need to have a form with a Title field and the binary data to
be printed as a posted file called Data.
  
