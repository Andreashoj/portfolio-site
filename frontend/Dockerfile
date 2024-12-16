# Development stage
FROM node:20-alpine AS development
WORKDIR /app
COPY package*.json ./
RUN npm install
EXPOSE 5173
CMD ["npm", "run", "dev", "--", "--host", "0.0.0.0"]

# Build stage
FROM node:20-alpine AS builder
WORKDIR /app
COPY package*.json ./
# Install all dependencies including devDependencies
RUN npm install
# Install the node adapter
RUN npm install @sveltejs/adapter-node
COPY . .
RUN npm run build

# Production stage
FROM node:20-alpine AS production
WORKDIR /app
# Copy all necessary files
COPY --from=builder /app/build ./build
COPY --from=builder /app/package.json ./
COPY --from=builder /app/package-lock.json ./
# Install only production dependencies
RUN npm ci --production
EXPOSE 3000
CMD ["node", "./build"]