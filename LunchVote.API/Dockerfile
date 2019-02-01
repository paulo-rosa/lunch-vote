FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["LunchVote.API/LunchVote.API.csproj", "LunchVote.API/"]
RUN dotnet restore "LunchVote.API/LunchVote.API.csproj"
COPY . .
WORKDIR "/src/LunchVote.API"
RUN dotnet build "LunchVote.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LunchVote.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LunchVote.API.dll"]