# Use the official Microsoft .NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the Docker container
WORKDIR /src

# Copy the .csproj file(s) and restore packages
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the files and build the app
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Use the official Microsoft .NET Core runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Set the working directory in the Docker container
WORKDIR /app

# Copy the published app to the working directory
COPY --from=build /app/publish .

# Set the ASPNETCORE_ENVIRONMENT variable to Production
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose port 5290 for the app
EXPOSE 5290

EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "PhoneResQ.API.dll"]