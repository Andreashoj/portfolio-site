// src/lib/types.ts
interface SanityPost {
    title: string;
    author: string;
    body: any; 
    publishedAt?: string;
}

// For your page data
interface PageData {
    post: SanityPost;
}