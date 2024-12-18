// src/routes/blog/+page.server.ts
export const prerender = true

export function load({ data }) {
    return {
        post: data.post
    }
}
