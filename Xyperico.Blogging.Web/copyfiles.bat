xcopy bin\Xyperico.Blogging.* ..\..\Xyperico.Website\Xyperico.Website.Host\bin\Areas /I /Y /D
rem xcopy bin\da\Xyperico.Blogging.* ..\..\Xyperico.Website\Xyperico.Website.Host\bin\Areas\da /I /Y /D

mkdir ..\..\Xyperico.Website\Xyperico.Website.Host\Areas\Blogging\Views
xcopy Areas\Blogging\Views\*.* ..\..\Xyperico.Website\Xyperico.Website.Host\Areas\Blogging\Views\ /I /Y /S /D
