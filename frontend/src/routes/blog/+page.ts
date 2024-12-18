export function load({ data }) {
    return {
        posts: data.posts.map(post => ({
            ...post,
        }))
    }
}