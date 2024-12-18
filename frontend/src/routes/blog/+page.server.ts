// src/routes/blog/+page.server.ts
import { client } from '$lib/sanity'

export async function load() {
    const posts = await client.fetch(`
        *[_type == "post"] {
            title,
            slug,
            body,
            publishedAt,
            "author": author->name
        }
    `)
    console.log(posts)
    return { posts }
}