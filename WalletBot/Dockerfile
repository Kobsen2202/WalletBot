FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WalletBot/WalletBot.csproj", "WalletBot/"]
RUN dotnet restore "WalletBot/WalletBot.csproj"
COPY . .
WORKDIR "/src/WalletBot"
RUN dotnet build "WalletBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WalletBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WalletBot.dll"]
