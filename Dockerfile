FROM mcr.microsoft.com/dotnet/core/sdk:2.2.402

LABEL version="1.0" maintainer="Santana"
LABEL description="Enquete Api .Net Core"

WORKDIR /app
COPY Publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "EnqueteApi.dll"]
