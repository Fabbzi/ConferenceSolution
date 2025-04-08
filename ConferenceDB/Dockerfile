# Use the official Microsoft SQL Server 2022 image as the base
FROM mcr.microsoft.com/mssql/server:2022-latest
# Set environment variables for SQL Server
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=your_Express
ENV MSSQL_SA_PASSWORD=Linuspenis69

# Switch to root user to install dependencies
USER root 
RUN mkdir -p /app/init-scripts

# Copy the initialization script into the container
COPY init-database.sql /app/init-scripts

# Set permissions for the initialization script
RUN apt-get update && apt-get install -y mssql-tools unixodbc-dev && apt-get clean

# Use the mssql user to run SQL Server
USER mssql

# Health-Check to ensure SQL Server is running
HEALTHCHECK --interval=10s --timeout=5s --start-period=30s --retries=5 \
    CMD /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -Q "SELECT 1" || exit 1

# Command to start SQL server and execute the initialization script safely
CMD /bin/bash -c "/opt/mssql/bin/sqlservr & sleep 45 && \
    if /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -Q 'SELECT name FROM sys.databases WHERE name = \"Conference\"' | grep -q Conference; then \
    echo 'Database already exists, skipping initialization.'; \
    else \
    echo 'Initializing database...'; \
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -i /app/init-scripts/init-database.sql; \
    fi && wait"
