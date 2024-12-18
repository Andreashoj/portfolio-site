<script lang="ts">
    import BlogComponent from "$components/features/BlogComponent.svelte";

    export let data;
</script>

<article>
    <h1>{data.post.title}</h1>
    <p>By {data.post.author}</p>
    <BlogComponent content="{data.post.body}"/>
</article>