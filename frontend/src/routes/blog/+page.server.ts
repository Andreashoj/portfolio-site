// src/routes/blog/+page.server.ts
import client from '$lib/contentful'

export async function load() {
    const response = await client.getEntries({
        content_type: 'article'  // Your content type ID
    })

    console.log(response.items[0]);
    return {
        posts: response.items
    }
}