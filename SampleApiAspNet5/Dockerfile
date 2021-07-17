#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SampleApiAspNet5/SampleApiAspNet5.csproj", "SampleApiAspNet5/"]
RUN dotnet restore "SampleApiAspNet5/SampleApiAspNet5.csproj"
COPY . .
WORKDIR "/src/SampleApiAspNet5"
RUN dotnet build "SampleApiAspNet5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleApiAspNet5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleApiAspNet5.dll"]