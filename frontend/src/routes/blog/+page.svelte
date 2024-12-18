<script lang="ts">
    import Prism from 'prismjs'
    import 'prismjs/themes/prism-tomorrow.css'
    // import 'prismjs/themes/prism-dark.css'
    import 'prismjs/components/prism-typescript'
    import 'prismjs/components/prism-javascript'
    import 'prismjs/components/prism-css'
    import 'prismjs/components/prism-markup' // for HTML
    import { renderContent } from '$lib/sanityRenderer'
    import { onMount } from 'svelte'
    export let data
</script>

<style>
    :global(.code-window) {
        border-radius: 8px;
        overflow: hidden;
        background: #2d2d2d;
        margin: 1.5rem 0;
        box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
    }

    :global(.code-header) {
        background: #3d3d3d;
        padding: 8px 16px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    :global(.window-buttons) {
        display: flex;
        gap: 8px;
    }

    :global(.window-buttons span) {
        width: 12px;
        height: 12px;
        border-radius: 50%;
        display: inline-block;
    }

    :global(.close) {
        background: #ff5f56;
    }

    :global(.minimize) {
        background: #ffbd2e;
    }

    :global(.maximize) {
        background: #27c93f;
    }

    :global(.language) {
        color: #999;
        font-size: 0.9rem;
    }

    :global(pre) {
        margin: 0;
        padding: 1.5rem;
    }

    :global(pre code) {
        font-family: 'JetBrains Mono', monospace;
        font-size: 0.9rem;
        line-height: 1.5;
    }
    :global(.tab) {
        background: #363636;
        padding: 4px 12px;
        border-radius: 4px 4px 0 0;
        margin-left: 16px;
    }

    :global(.filename) {
        color: #fff;
        font-size: 0.9rem;
        font-family: monospace;
    }

    :global(.code-header) {
        background: #2d2d2d;
        padding: 8px 16px;
        display: flex;
        align-items: center;
    }
</style>
{#each data.posts as post}
    <article>
        <h1>{post.title}</h1>
        {@html renderContent(post.body)}
    </article>
{/each}