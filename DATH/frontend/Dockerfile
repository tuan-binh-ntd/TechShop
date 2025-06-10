# Base image with Node.js
FROM node:18-alpine

# Set working directory
WORKDIR /app

# Install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of the application
COPY . .

# Expose dev server port
EXPOSE 4200

# Start the Angular dev server
CMD ["npm", "start"]
