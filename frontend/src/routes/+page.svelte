<script lang="ts">
    import { onMount } from "svelte";

    onMount(() => {
        fetch('/api/weatherforecast')
    })
</script>
<h1>Welcome to SvelteKit - muslinge pigen her</h1>
<p>Visit <a href="https://svelte.dev/docs/kit">svelte.dev/docs/kit</a> to read the documentation</p>
