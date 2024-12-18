<script lang="ts">
    export let data
</script>

<div class="flex flex-col bg-gray-400 my-28">
    {#each data.posts as post}
        <a href="blog/{post.slug.current}">{post.slug.current}</a>
    {/each}
</div>