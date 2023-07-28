# https://learn.microsoft.com/en-us/dotnet/core/tools/
# initialiser le projet 
dotnet new console -o CoinGecko
dotnet new console --framework net7.0
dotnet add package Newtonsoft.Json --version 13.0.3
# restsharp
dotnet add package RestSharp --version 110.2.0
# command line parser
dotnet add package CommandLineParser --version 2.9.1
# tester le programme 
dotnet build
dotnet run
dotnet run --configuration Release
# debug 
# https://learn.microsoft.com/en-us/dotnet/core/tutorials/debugging-with-visual-studio-code?pivots=dotnet-7-0

# publish
# https://learn.microsoft.com/en-us/dotnet/core/tutorials/publishing-with-visual-studio-code?pivots=dotnet-7-0
dotnet publish --configuration Release