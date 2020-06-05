FROM microsoft/dotnet:2.2-sdk-alpine

LABEL version="1.0" maintainer="Santana"
LABEL description="Enquete Api .Net Core"

WORKDIR /app
COPY Publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "EnqueteApi.dll"]
