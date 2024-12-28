# Development stage
FROM node:20-alpine AS development
WORKDIR /app
COPY package*.json ./
RUN npm install
EXPOSE 5173
CMD ["npm", "run", "dev", "--", "--host", "0.0.0.0"]

# Build stage
FROM node:18-alpine AS builder
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .

ARG PUBLIC_API_KEY
ENV VITE_PUBLIC_API_KEY=$PUBLIC_API_KEY
RUN npm run build

# Production stage
FROM nginx:alpine AS production
COPY --from=builder /app/build /usr/share/nginx/html

# The container needs to exist to hold the files, but doesn't need to run nginx
CMD ["tail", "-f", "/dev/null"]